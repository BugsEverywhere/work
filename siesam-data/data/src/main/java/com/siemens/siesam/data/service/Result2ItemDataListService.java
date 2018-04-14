package com.siemens.siesam.data.service;

import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.DataMain;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

/**
 * Created by Chen Zhuo on 2016/9/18.
 */
@Service("Result2ItemDataListService")
public class Result2ItemDataListService {

    public static final Logger LOGGER = LoggerFactory.getLogger(DataMain.class);

    public List<ItemData> changeResult2ItemData(ResultSet resultSet){

        List<ItemData> resultList = new ArrayList<ItemData>();

        try {
            while(resultSet.next()){
                ItemData itemData = new ItemData();
                if (!resultSet.getString("value").isEmpty()){
                    itemData.setValue(resultSet.getString("value"));
                }else{
                    continue;
                }
                if (!resultSet.getString("time").isEmpty()) {
                    Calendar cal = Calendar.getInstance();
                    String timeString = resultSet.getString("time");
                    String [] timeStamp1 = timeString.split("-",-1);
                    int year = Integer.parseInt(timeStamp1[0]);
                    int month = Integer.parseInt(timeStamp1[1]);
                    String [] timeStamp2 = timeStamp1[2].split(" ",-1);
                    int date = Integer.parseInt(timeStamp2[0]);
                    String [] timeStamp3 = timeStamp2[1].split(":",-1);
                    int hour = Integer.parseInt(timeStamp3[0]);
                    int minute = Integer.parseInt(timeStamp3[1]);
                    String [] timeStamp4 = timeStamp3[2].split("\\.",-1);
                    int second = Integer.parseInt(timeStamp4[0]);
                    int milLisecond = Integer.parseInt(timeStamp4[1]);
                    cal.set(Calendar.YEAR,year);
                    cal.set(Calendar.MONTH,month-1);
                    cal.set(Calendar.DATE,date);
                    cal.set(Calendar.HOUR_OF_DAY,hour);
                    cal.set(Calendar.MINUTE,minute);
                    cal.set(Calendar.SECOND,second);
                    cal.set(Calendar.MILLISECOND,milLisecond);
                    itemData.setTimeStamp(cal.getTimeInMillis());

                }else{
                    continue;
                }
                resultList.add(itemData);
            }
        } catch (SQLException e) {
            LOGGER.error("change ResultSet to ItemData failed, SQLException: "+e.getMessage()+"error code: "+e.getErrorCode());
        }

        return resultList;
    }


}
