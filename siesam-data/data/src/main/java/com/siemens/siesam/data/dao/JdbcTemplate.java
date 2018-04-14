package com.siemens.siesam.data.dao;

import com.mchange.v2.c3p0.ComboPooledDataSource;
import org.springframework.jdbc.core.namedparam.NamedParameterJdbcTemplate;
import org.springframework.stereotype.Component;

/**
 * Created by Simons on 2017/5/14.
 */
@Component("JdbcTemplate")
public class JdbcTemplate {

    private static NamedParameterJdbcTemplate template = new NamedParameterJdbcTemplate(new ComboPooledDataSource("myc3p0xml"));

    public NamedParameterJdbcTemplate getTemplate() {
        return template;
    }
}
