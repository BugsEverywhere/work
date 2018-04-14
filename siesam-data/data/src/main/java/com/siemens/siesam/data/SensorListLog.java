package com.siemens.siesam.data;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Simons on 2017/4/20.
 */
public class SensorListLog implements Runnable{

    public final Logger LOGGER = LoggerFactory.getLogger(SensorListLog.class);

    @Override
    public void run() {

        int accumulation = 0;

        while(true){

            int totalSensors;
            int totalResults;

            synchronized (DataMain.asyncItemList){

                totalSensors = DataMain.asyncItemList.size();
                synchronized (DataMain.itemResult){
                    totalResults = DataMain.itemResult.size();

                    if(accumulation==360){
                        LOGGER.info("total realtime sensors "+totalSensors);
                        LOGGER.info("total realtime results "+totalResults);
                        accumulation=0;
                    }else{
                        accumulation++;
                    }

                    List<String> exceptionItems = new ArrayList<>();
                    for (String singleitemID : DataMain.asyncItemList){
                        if(!DataMain.itemResult.keySet().contains(singleitemID)){
                            exceptionItems.add(singleitemID);
                        }
                    }
                    LOGGER.info(exceptionItems.size()+" exception items,they are "+exceptionItems);

                    List<String> subStringList;
                    if(exceptionItems.size()>20){

                        subStringList = exceptionItems.subList(0,20);

                    }else{

                        subStringList = exceptionItems;

                    }

                    DistributeThread dispatch = new DistributeThread(subStringList,2);
                    dispatch.itemsToThreads();
                }
            }

            try {
                Thread.sleep(1000L*10);

            } catch (InterruptedException e) {
                LOGGER.error("Why you wake me up!");
            }
        }
    }
}
