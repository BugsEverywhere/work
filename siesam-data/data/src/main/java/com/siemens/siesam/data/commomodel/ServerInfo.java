package com.siemens.siesam.data.commomodel;

import org.springframework.stereotype.Component;

/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/20.
 */
@Component
public class ServerInfo {

        private String host;
        private String domain;
        private String username;
        private String password;
        private String clsid;
        private String progid;


        public String getDomain() {
            return domain;
        }

        public void setDomain(String domain) {
            this.domain = domain;
        }

        public String getHost() {
            return host;
        }

        public void setHost(String host) {
            this.host = host;
        }

        public String getUsername() {
            return username;
        }

        public void setUsername(String username) {
            this.username = username;
        }

        public String getPassword() {
            return password;
        }

        public void setPassword(String password) {
            this.password = password;
        }

        public String getClsid() {
            return clsid;
        }

        public void setClsid(String clsid) {
            this.clsid = clsid;
        }

        public String getProgid() {
            return progid;
        }

        public void setProgid(String progid) {
            this.progid = progid;
        }



}
