package com.siemens.siesam.data.executor;

import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.DataMain;
import com.siemens.siesam.data.commomodel.OpcClient;
import com.siemens.siesam.data.conf.SpringContextUtil;
import com.siemens.siesam.data.service.ItemState2ItemDataService;
import org.jinterop.dcom.common.JIException;
import org.openscada.opc.lib.common.AlreadyConnectedException;
import org.openscada.opc.lib.common.NotConnectedException;
import org.openscada.opc.lib.da.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;

import java.net.UnknownHostException;
import java.text.SimpleDateFormat;
import java.util.*;


/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/20.
 */
public class OpcAsyncRealTimeReadExecutor implements Runnable{

<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
        public final Logger LOGGER = LoggerFactory.getLogger(OpcAsyncRealTimeRead.class);

        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
=======
        public final Logger LOGGER = LoggerFactory.getLogger(OpcAsyncRealTimeReadExecutor.class);

        private ItemState2ItemDataService itemState2ItemDataService;

        private SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java

        private List<String> tobeAddedItemList = new ArrayList<String>();

        private List<String> alreadyAddedItemList = new ArrayList<String>();

        private OpcClient client = null;

        private int realtimeThreadIndex;

        private AccessBase access = null;

<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
        public OpcAsyncRealTimeRead( OpcClient opcClient,int index){
=======
        public static Set<String> pointSet = new HashSet<>();

        public OpcAsyncRealTimeReadExecutor(OpcClient opcClient, int index){
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java

                this.realtimeThreadIndex = index;

                this.client = opcClient;
        }

        public void addItem(String itemName){
                this.tobeAddedItemList.add(itemName);
        }

        public void addItems(List<String>itemNames){
                this.tobeAddedItemList.addAll(itemNames);
        }

        private void connect(){
                try {
                        this.client.connect();
                } catch (AlreadyConnectedException e) {
                        LOGGER.error("OPC async read connection failed, AlreadyConnectedException. "+e.getMessage());
                } catch (JIException e) {
                        LOGGER.error("OPC async read connection failed, JIException. "+e.getMessage()+" error code"+e.getErrorCode());
                } catch (UnknownHostException e) {
                        LOGGER.error("OPC async read connection failed, UnknownHostException. "+e.getMessage());
                }
        }

        private void createAccess() {
                try {
                        this.access = new SyncAccess(this.client.getOpcServer(), 500);

                } catch (UnknownHostException e) {
                        LOGGER.error("OPC async read create access failed, UnknownHostException. "+e.getMessage());
                } catch (NotConnectedException e) {
                        LOGGER.error("OPC async read create access failed, NotConnectedException. "+e.getMessage());
                } catch (JIException e) {
                        LOGGER.error("OPC async read create access failed, JIException. "+e.getMessage()+" error code"+e.getErrorCode());
                } catch (DuplicateGroupException e) {
                        LOGGER.error("OPC async read create access failed, DuplicateGroupException. "+e.getMessage());
                }

        }

<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
        private void addItemsToAccess(List<String> itemList){
=======
        private void addItemsToAccess(List<String> itemList,ItemState2ItemDataService itemState2ItemDataService){
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java
                Iterator<String> itemIterator = itemList.iterator();
                while(itemIterator.hasNext()){
                        String currentItem = itemIterator.next();
                        try {
                                access.addItem(currentItem, new DataCallback() {
                                        public void changed(Item item, ItemState itemState) {
<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
                                                ItemState2ItemData itemState2ItemData = new ItemState2ItemData(itemState);
                                                ItemData currentItemData = itemState2ItemData.getItemData();
                                                DataMain.itemResult.put(currentItem, currentItemData);
                                        }
                                });
=======
                                                ItemData currentItemData = itemState2ItemDataService.getItemData(itemState);
                                                pointSet.add(currentItem);
                                                DataMain.itemResult.put(currentItem, currentItemData);
                                        }
                                });
                                synchronized (DataMain.accessAddCount){
                                        DataMain.accessAddCount++;
                                }
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java

                        } catch (JIException e) {
                                LOGGER.error("OPC access add item failed, DuplicateGroupException. "+e.getMessage()+" error code:"+e.getErrorCode());
                        } catch (AddFailedException e) {
                                LOGGER.error("OPC access add item failed, DuplicateGroupException. "+e.getMessage());
                        }
                }
                this.alreadyAddedItemList.addAll(itemList);
                this.tobeAddedItemList.clear();
        }

        public OpcClient getClient(){

                return this.client;
        }

        private void start(){

                this.access.bind();
        }

        public void run() {

                this.itemState2ItemDataService = SpringContextUtil.getBean("ItemState2ItemDataService");

                this.connect();

                this.createAccess();

                while(tobeAddedItemList.size()==0)
                {
                        try {
                                Thread.sleep(500);
                        } catch (InterruptedException e) {
                                LOGGER.error("Thread sleep error during waiting for the first async item. "+e.getMessage());
                        }
                }

<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
                this.addItemsToAccess(this.tobeAddedItemList);
=======
                this.addItemsToAccess(this.tobeAddedItemList,this.itemState2ItemDataService);
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java

                this.start();

                while(true){

                        if(!this.tobeAddedItemList.isEmpty()) {
<<<<<<< HEAD:data/src/main/java/com/siemens/siesam/data/OpcAsyncRealTimeRead.java
                                addItemsToAccess(this.tobeAddedItemList);
=======
                                addItemsToAccess(this.tobeAddedItemList,this.itemState2ItemDataService);
>>>>>>> Springdev:data/src/main/java/com/siemens/siesam/data/executor/OpcAsyncRealTimeReadExecutor.java
                        }

                        try {
                                Thread.sleep(500);
                        } catch (InterruptedException e) {
                                LOGGER.error("Thread sleep error during waiting for new async item. "+e.getMessage());
                        }

                }

        }
}
