package com.siemens.siesam.data;

import java.io.*;
import java.net.UnknownHostException;
import java.nio.charset.Charset;
import java.nio.charset.CharsetDecoder;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;


import com.siemens.mvp.thrift.thrift_client.DataInterface;
import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.commomodel.OpcClient;
import com.siemens.siesam.data.commomodel.ServerInfo;
import com.siemens.siesam.data.executor.OpcAsyncRealTimeReadExecutor;
import com.siemens.siesam.data.executor.SensorListLogExecutor;
import org.apache.thrift.TProcessor;
import org.apache.thrift.protocol.TCompactProtocol;
import org.apache.thrift.protocol.TProtocolFactory;
import org.apache.thrift.server.TThreadPoolServer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.apache.thrift.server.TServer;
import org.apache.thrift.transport.TServerSocket;
import org.apache.thrift.transport.TServerTransport;
import org.apache.thrift.transport.TTransportException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;

/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/15.
 */
@ComponentScan
public class DataMain {

    public static final Logger LOGGER = LoggerFactory.getLogger(DataMain.class);

<<<<<<< HEAD
    public static List<String> asyncItemList = null;

    public static ConcurrentHashMap<String,ItemData> itemResult =null;

    public static ConcurrentHashMap<String,List<ItemData>> historicalResult = new ConcurrentHashMap<>();

    public static List<OpcAsyncRealTimeRead> currentThreadList = null;

    private static TServer server = null;

    public static ExecutorService ThreadPool = null;
=======
    public static Integer accessAddCount = 0;

    public static List<String> asyncItemList = null;

    public static ConcurrentHashMap<String,ItemData> itemResult =null;

    public static ConcurrentHashMap<String,List<ItemData>> historicalResult = new ConcurrentHashMap<>();
>>>>>>> Springdev

    public static List<OpcAsyncRealTimeReadExecutor> currentThreadList = null;

    private static TServer server = null;

    public static ExecutorService ThreadPool = null;

    public static ServerInfo serverConfiguration = null;

    public static int realtmeThreadCount;

    public static InterfaceImpl handler;

    public static DataInterface.Processor processor;

    public static Integer opcClientThreadCursor = 0;

    public static int thriftPort = 0;

    @Autowired
    private InterfaceImpl interfaceImpl;

    public static boolean readProp(){
        Properties prop = new Properties();

        File f = new File("configuration.properties");
        CharsetDecoder decoder = Charset.forName("utf-8").newDecoder();

        try {
            if(f.exists()){
                InputStream propertiesStream = new FileInputStream(f);
                InputStreamReader propertiesStreamReader = new InputStreamReader(propertiesStream,decoder);
                prop.load(propertiesStreamReader);
                propertiesStream.close();
                propertiesStreamReader.close();
            }else{
                InputStream propertiesStream= DataMain.class.getResourceAsStream("/configuration.properties");
                InputStreamReader propertiesStreamReader = new InputStreamReader(propertiesStream,decoder);
                prop.load(propertiesStreamReader);
                propertiesStream.close();
                propertiesStreamReader.close();
            }

            serverConfiguration = new ServerInfo();
            serverConfiguration.setHost(prop.getProperty("opc.server.host", ""));
            serverConfiguration.setDomain(prop.getProperty("opc.server.domain", ""));
            serverConfiguration.setUsername(prop.getProperty("opc.server.username", ""));
            serverConfiguration.setPassword(prop.getProperty("opc.server.password", ""));
            serverConfiguration.setClsid(prop.getProperty("opc.server.clsid", ""));
            serverConfiguration.setProgid(prop.getProperty("opc.server.progid", ""));
            realtmeThreadCount=Integer.parseInt(prop.getProperty("opc.client.threadCount", ""));
            thriftPort = Integer.parseInt(prop.getProperty("thrift.port", "9090"));

        } catch (IOException e) {
            LOGGER.error("Error in reading opcserver properties file",e.getMessage());
            return false;
        }


        return true;
    }

    public static void main(String [] args) {

<<<<<<< HEAD
=======
        ApplicationContext context = new AnnotationConfigApplicationContext(DataMain.class);

        DataMain dataMain = context.getBean(DataMain.class);

>>>>>>> Springdev
        if(!readProp()){
            return;
        }


        //Create a thread pool for Async read
        {
            ThreadPool = Executors.newFixedThreadPool(realtmeThreadCount);

            currentThreadList = new ArrayList<>();

            itemResult = new ConcurrentHashMap<>();

            asyncItemList = new ArrayList<>();

            for (int i = 0; i < realtmeThreadCount; i++) {
<<<<<<< HEAD
                OpcAsyncRealTimeRead asyncRead = new OpcAsyncRealTimeRead(new OpcClient(serverConfiguration),i);
=======
                OpcAsyncRealTimeReadExecutor asyncRead = new OpcAsyncRealTimeReadExecutor(new OpcClient(serverConfiguration),i);
>>>>>>> Springdev
                ThreadPool.execute(asyncRead);
                currentThreadList.add(asyncRead);
            }
        }


        //thrift server
        {
            handler = new InterfaceImpl();
            processor = new DataInterface.Processor(handler);

            TServerTransport serverTransport = null;
            try {
                serverTransport = new TServerSocket(thriftPort);
            } catch (TTransportException e) {
                LOGGER.error("failed to create a thrift socket, TTransportException");
                e.printStackTrace();
            }

            TProtocolFactory proFactory = new TCompactProtocol.Factory();
<<<<<<< HEAD
            TProcessor processor = new DataInterface.Processor(new InterfaceImpl());
            server = new TThreadPoolServer(new TThreadPoolServer.Args(serverTransport).protocolFactory(proFactory).processor(processor));
        }

        SensorListLog sensorListLog = new SensorListLog();
=======
            TProcessor processor = new DataInterface.Processor(dataMain.getInterfaceImpl());
            server = new TThreadPoolServer(new TThreadPoolServer.Args(serverTransport).protocolFactory(proFactory).processor(processor));
        }

        SensorListLogExecutor sensorListLog = new SensorListLogExecutor();
>>>>>>> Springdev
        Thread thread = new Thread(sensorListLog);
        thread.start();


        while (true){

            server.serve();

            server.stop();

            LOGGER.error("thrift server stopped, serving again...");

            try {
                Thread.sleep(200);
            } catch (InterruptedException e) {
                LOGGER.error("Thread sleep error"+e.getMessage());
            }

        }


    }

    public InterfaceImpl getInterfaceImpl() {
        return interfaceImpl;
    }


}
