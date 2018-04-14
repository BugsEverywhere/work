package com.siemens.siesam.data.executor;

import com.siemens.siesam.data.DataMain;
import com.siemens.siesam.data.conf.SpringContextUtil;
import com.siemens.siesam.data.service.DistributeThreadService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Simons on 2017/4/20.
 */
public class SensorListLogExecutor implements Runnable{

    public final Logger LOGGER = LoggerFactory.getLogger(SensorListLogExecutor.class);

    private final int ONCERESOLVENUM = DataMain.realtmeThreadCount;
    private final int EXCEPTIONITEMTYPE = 2;
    private final long CYCLETIME = 1000L * 10;

    private DistributeThreadService distributeThreadService;

    @Override
    public void run() {

        this.distributeThreadService = SpringContextUtil.getBean("DistributeThreadService");

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
                    if(exceptionItems.size()>ONCERESOLVENUM){

                        subStringList = exceptionItems.subList(0,ONCERESOLVENUM);

                    }else{

                        subStringList = exceptionItems;

                    }

                    distributeThreadService.itemsToThreads(subStringList,EXCEPTIONITEMTYPE);

                }
            }

            try {
                Thread.sleep(CYCLETIME);

            } catch (InterruptedException e) {
                LOGGER.error("Why you wake me up!");
            }
        }
    }
}
