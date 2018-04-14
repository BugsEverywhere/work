package com.siemens.siesam.data.commomodel;


import org.jinterop.dcom.common.JIException;
import org.openscada.opc.lib.common.AlreadyConnectedException;
import org.openscada.opc.lib.common.ConnectionInformation;
import org.openscada.opc.lib.da.AutoReconnectController;
import org.openscada.opc.lib.da.Server;
import org.springframework.stereotype.Component;

import java.net.UnknownHostException;
import java.util.concurrent.Executors;


/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/20.
 */
@Component
public class OpcClient {

        private Server opcServer = null;

        public OpcClient(ServerInfo sc) {

            final ConnectionInformation ci = new ConnectionInformation();
            ci.setHost ( sc.getHost() );
            ci.setDomain ( sc.getDomain());
            ci.setUser ( sc.getUsername() );
            ci.setPassword ( sc.getPassword() );
            ci.setClsid ( sc.getClsid() );
            ci.setProgId( sc.getProgid() );

            opcServer = new Server(ci, Executors.newSingleThreadScheduledExecutor());

        }

        public void connect() throws AlreadyConnectedException, JIException, UnknownHostException {
            final AutoReconnectController autoReconnectController = new AutoReconnectController(this.opcServer);
            autoReconnectController.connect();
        }

        public Server getOpcServer() {
            return opcServer;
        }


}
