package com.siemens.siesam.data.dao;

import com.mchange.v2.c3p0.ComboPooledDataSource;
import com.siemens.siesam.data.DataMain;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.beans.PropertyVetoException;
import java.sql.Connection;
import java.sql.SQLException;

/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/9/27.
 */
public class JdbcConnection {

    private static final Logger LOGGER = LoggerFactory.getLogger(DataMain.class);

    private static JdbcConnection jdbcConnection;

    private  ComboPooledDataSource cpds;

    private JdbcConnection(){
        cpds = new ComboPooledDataSource("myc3p0xml");
    }

    static{
        jdbcConnection = new JdbcConnection();
    }

    public static JdbcConnection getInstance(){
        return jdbcConnection;
    }

    public  Connection getConnection(){
        try {
            return cpds.getConnection();
        } catch (SQLException e) {
            LOGGER.error("JDBC connect failed: "+e.getMessage()+". error code:");
        }
        return null;
    }


}
