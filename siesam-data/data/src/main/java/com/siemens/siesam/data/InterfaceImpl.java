package com.siemens.siesam.data;

import com.siemens.mvp.thrift.thrift_client.DataInterface;
import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.dao.JdbcConnection;
import com.siemens.siesam.data.executor.HistoricalReadExecutor;
import com.siemens.siesam.data.service.DistributeThreadService;
import com.siemens.siesam.data.service.ItemState2ItemDataService;
import com.siemens.siesam.data.service.Result2ItemDataListService;
import org.apache.thrift.TException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.Date;


/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/15.
 */
@Component
public class InterfaceImpl implements DataInterface.Iface{

    @Autowired
    private DistributeThreadService distributeThreadService;

    @Autowired
    private ItemState2ItemDataService itemState2ItemDataService;

    @Autowired
    private Result2ItemDataListService result2ItemDataListService;

    private static final Logger LOGGER = LoggerFactory.getLogger(DataMain.class);

    private SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    public ItemData asyncReadItem(String itemName){
        List<String> asyncReadItemList = new ArrayList<>();
        asyncReadItemList.add(itemName);
<<<<<<< HEAD
        DistributeThread dispatch = new DistributeThread(asyncReadItemList,1);
        dispatch.itemsToThreads();
=======
        distributeThreadService.itemsToThreads(asyncReadItemList,1);
>>>>>>> Springdev
        //wait for dumping the value into itemResult
        synchronized (DataMain.itemResult) {
            if(DataMain.itemResult.get(itemName)!=null) {
                ItemData result = DataMain.itemResult.get(itemName);
                return result;
            }
        }
        return null;
    }

    public List<ItemData> asyncReadItems(List<String> itemNames){

        List<ItemData> readResult = new ArrayList<>();
<<<<<<< HEAD
        DistributeThread dispatch = new DistributeThread(itemNames,1);
        dispatch.itemsToThreads();
=======
        distributeThreadService.itemsToThreads(itemNames,1);
>>>>>>> Springdev
        for(String currentItem:itemNames) {
            synchronized (DataMain.itemResult) {
                if (DataMain.itemResult.get(currentItem) != null) {
                    readResult.add(DataMain.itemResult.get(currentItem));
                }else{
                    readResult.add(new ItemData());
                }
            }
        }
        return readResult;
    }

    @SuppressWarnings("JpaQueryApiInspection")
    public List<ItemData> historicData(String itemName, long startTime, long endTime, String interval)  {

        List<ItemData> historicResult;

        Date startDate = new Date(startTime);
        Date endDate = new Date(endTime);
        String startTimeString = sdf.format(startDate);
        String endTimeString = sdf.format(endDate);

        try {
            Connection conn = JdbcConnection.getInstance().getConnection();
            PreparedStatement statement = conn.prepareStatement("SELECT tag, time, value, status FROM piarchive..piinterp2 WHERE tag = ? AND time >= DATE(?) AND time <= DATE(?) AND timestep = TIME(?)");
            statement.setString(1,itemName);
            statement.setString(2,startTimeString);
            statement.setString(3,endTimeString);
            statement.setString(4,interval);
            ResultSet resultSet = statement.executeQuery();
            historicResult = result2ItemDataListService.changeResult2ItemData(resultSet);
            resultSet.close();
            statement.close();
            conn.close();

        } catch (SQLException e) {
            LOGGER.error("failed to query historical data through JDBC, SQLException: "+e.getMessage()+". error code:"+e.getErrorCode());
            return null;
        }

        return historicResult;
    }

    @SuppressWarnings("JpaQueryApiInspection")
    public Map<String,List<ItemData>> batchHistoricalData(List<String> itemList, long startTime, long endTime, String interval){

        Map<String, List<ItemData>> item2ItemData = new HashMap<>();

        if (!itemList.isEmpty()) {

            Iterator<String> itemIDIterator =  itemList.iterator();

            HistoricalReadExecutor historicalReadExecutor;

            Date startDate = new Date(startTime);
            String starString = sdf.format(startDate);

            Date endDate = new Date(endTime);
            String endString = sdf.format(endDate);

            int threadIndex = 0;

            Vector<Thread> ts = new Vector<>();

            while (itemIDIterator.hasNext()) {

                List<String> singleItemList = new ArrayList<>();

                String singleID = itemIDIterator.next();

                singleItemList.add(singleID);

                historicalReadExecutor = new HistoricalReadExecutor(singleItemList,starString,endString,interval);

                Thread thread = new Thread(historicalReadExecutor);

                thread.start();

                ts.add(thread);

                threadIndex++;

            }

            LOGGER.info(threadIndex+" threads are running to read historical data.");

            for(Thread st:ts){

                try {
                    st.join();
                } catch (InterruptedException e) {
                    LOGGER.error("Thread join error. "+e.getMessage());
                }

            }
        }

        Collection<String> resultItemSet = DataMain.historicalResult.keySet();

        Iterator<String> itemIDIterator = itemList.iterator();

        while(itemIDIterator.hasNext()){

            String singleItemID = itemIDIterator.next();

            if(resultItemSet.contains(singleItemID)){

                item2ItemData.put(singleItemID,DataMain.historicalResult.get(singleItemID));

            }else{

                item2ItemData.put(singleItemID,null);

            }

        }

        DataMain.historicalResult.clear();

        return item2ItemData;
    }

    public String changeItemID(String originalID, String changedID) throws TException {

        try {
            Connection conn =JdbcConnection.getInstance().getConnection();
            PreparedStatement statement = conn.prepareStatement("SELECT * FROM pipoint..pipoint2 WHERE tag = ?");
            statement.setString(1,originalID);
            ResultSet resultSet = statement.executeQuery();
            if (!resultSet.next()){return null;}
            statement = conn.prepareStatement("UPDATE pipoint..classic SET tag = ? WHERE tag = ?");
            statement.setString(1,changedID);
            statement.setString(2,originalID);
            statement.executeQuery();
            resultSet.close();
            statement.close();
            conn.close();

        } catch (SQLException e) {
            LOGGER.error("failed to change sensor's ID, SQLException: "+e.getMessage()+". error code:"+e.getErrorCode());
            return null;
        }

        return changedID;
    }

    public String deleteItem(String itemName){

        try {
            Connection conn =JdbcConnection.getInstance().getConnection();
            PreparedStatement statement = conn.prepareStatement("SELECT * FROM pipoint..pipoint2 WHERE tag = ?");
            statement.setString(1,itemName);
            ResultSet resultSet = statement.executeQuery();
            if (!resultSet.next()){return null;}
            statement = conn.prepareStatement("DELETE pipoint..classic WHERE tag = ?");
            statement.setString(1,itemName);
            statement.executeQuery();
            resultSet.close();
            statement.close();
            conn.close();
        } catch (SQLException e) {
            LOGGER.error("failed to delete sensor, SQLException: "+e.getMessage()+". error code:"+e.getErrorCode());
            return null;
        }

        return itemName;
    }

    public String insertItem(String itemName, String pointType){

        try {
            Connection conn =JdbcConnection.getInstance().getConnection();
            PreparedStatement statement = conn.prepareStatement("SELECT * FROM pipoint..pipoint2 WHERE tag = ?");
            statement.setString(1,itemName);
            ResultSet resultSet = statement.executeQuery();
            if (resultSet.next()){return null;}
            statement = conn.prepareStatement("INSERT pipoint..classic (tag, pointtypex) VALUES (?, ?)");
            statement.setString(1,itemName);
            statement.setString(2,pointType);
            statement.executeQuery();
            resultSet.close();
            statement.close();
            conn.close();

        } catch (SQLException e) {
            LOGGER.error("failed to insert sensor through JDBC, SQLException: "+e.getMessage()+". error code:"+e.getErrorCode());
            return null;
        }

        return itemName;
    }

}
