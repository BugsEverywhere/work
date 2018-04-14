package com.siemens.siesam.data.executor;

import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.DataMain;
import com.siemens.siesam.data.conf.SpringContextUtil;
import com.siemens.siesam.data.dao.JdbcConnection;
import com.siemens.siesam.data.service.Result2ItemDataListService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

/**
 * Created by Chen004Z on 4/14/2017.
 */
public class HistoricalReadExecutor implements Runnable {

    private static final Logger log = LoggerFactory.getLogger(HistoricalReadExecutor.class);

    private Result2ItemDataListService result2ItemDataListService;

    private List<String> itemList;

    private String startTime;

    private String endTime;

    private String interval;

    private Connection conn;

    private PreparedStatement statement;

    List<ItemData> itemDataList;

    private final int FIRST_PARAM = 1;

    private final int SECOND_PARAM = 2;

    private final int THIRD_PARAM = 3;

    private final int FOURTH_PARAM = 4;

    public HistoricalReadExecutor(List<String> itemList,String startTime,String endTime,String interval){

        this.itemList = itemList;

        this.startTime = startTime;

        this.endTime = endTime;

        this.interval = interval;

    }

    @Override
    public void run() {

        result2ItemDataListService = SpringContextUtil.getBean("Result2ItemDataListService");

        conn = JdbcConnection.getInstance().getConnection();

        try {
            statement = conn.prepareStatement("SELECT tag, time, value, status FROM piarchive..piinterp2 WHERE tag = ? AND time >= DATE(?) AND time <= DATE(?) AND timestep = TIME(?)");

            if(!itemList.isEmpty()){

                for(String singleItem:itemList){

                    statement.setString(FIRST_PARAM,singleItem);
                    statement.setString(SECOND_PARAM,startTime);
                    statement.setString(THIRD_PARAM,endTime);
                    statement.setString(FOURTH_PARAM,interval);

                    ResultSet resultSet = statement.executeQuery();

                    itemDataList = result2ItemDataListService.changeResult2ItemData(resultSet);

                    DataMain.historicalResult.put(singleItem,itemDataList);

                    resultSet.close();
                }
            }

        } catch (SQLException e) {
            log.error("historical-read error. "+e.getMessage()+" error code:"+e.getErrorCode());
        } finally {
            try {
                conn.close();
            } catch (SQLException e) {
                log.error("PI connection close error. "+e.getMessage());
            }
        }
    }
}
