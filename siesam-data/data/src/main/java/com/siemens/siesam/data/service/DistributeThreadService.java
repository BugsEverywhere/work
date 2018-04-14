package com.siemens.siesam.data.service;

import com.siemens.siesam.data.DataMain;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.*;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/25.
 */
@Service("DistributeThreadService")
public class DistributeThreadService {

    public static final Logger log = LoggerFactory.getLogger(DistributeThreadService.class);

    private final int NORMALITEMDISTRIBUTE = 1;
    private final int EXCEPTIONITEMDISTRIBUTE = 2;

<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/DistributeThread.java
    private final int NORMALITEMDISTRIBUTE = 1;
    private final int EXCEPTIONITEMDISTRIBUTE = 2;

    public DistributeThread(List<String> list,int itemType){

=======
    public void itemsToThreads(List<String> list,int itemType){

>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/service/DistributeThreadService.java
        if(itemType == NORMALITEMDISTRIBUTE){
            for(String itemName:list){
                synchronized (DataMain.asyncItemList) {
                    if (!DataMain.asyncItemList.contains(itemName)) {
                        DataMain.asyncItemList.add(itemName);
<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/DistributeThread.java
                        this.toBeDistributedList.add(itemName);
                    }
                }
            }
        }else if(itemType == EXCEPTIONITEMDISTRIBUTE){
            for(String itemName:list){
                this.toBeDistributedList.add(itemName);
            }
        }
    }

    public void itemsToThreads(){
=======
                    }
                }
            }
        }

>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/service/DistributeThreadService.java

        int threadIndex;
        synchronized(DataMain.opcClientThreadCursor){
            threadIndex = DataMain.opcClientThreadCursor;
        }

        int totalThreadCount;
        synchronized (DataMain.currentThreadList){
            totalThreadCount =  DataMain.currentThreadList.size();
        }

        if (!list.isEmpty()) {
                for (String singleItem : list) {

                    if (threadIndex <= totalThreadCount-1) {
                        synchronized(DataMain.currentThreadList) {
                            DataMain.currentThreadList.get(threadIndex).addItem(singleItem);
                            log.info("Item "+singleItem+" has been added into thread "+threadIndex);
                        }
                        threadIndex++;

                    } else {
                        threadIndex = 0;
                        synchronized(DataMain.currentThreadList) {
                            DataMain.currentThreadList.get(threadIndex).addItem(singleItem);
                            log.info("Item "+singleItem+" has been added into thread 0.");
                        }
                        threadIndex++;
                    }
                }
        }

        synchronized(DataMain.opcClientThreadCursor){
            DataMain.opcClientThreadCursor = threadIndex;
        }

    }

}
