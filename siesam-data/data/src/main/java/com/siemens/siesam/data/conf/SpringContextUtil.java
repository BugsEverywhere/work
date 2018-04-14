package com.siemens.siesam.data.conf;

import org.springframework.beans.BeansException;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.stereotype.Component;

/**
 * Created by Simons on 2017/4/26.
 */
@Component
public class SpringContextUtil implements ApplicationContextAware {
    //本类用于给线程注入java bean

    private static volatile ApplicationContext applicationContext; // Spring应用上下文环境

    //只要实现了ApplicationContextAware接口，该方法会在启动项目时自动执行，从而初始化applicationContext
    @Override
    public void setApplicationContext(ApplicationContext applicationContext) throws BeansException {
        SpringContextUtil.applicationContext = applicationContext;
    }


    public static ApplicationContext getApplicationContext() {
        return applicationContext;
    }

    @SuppressWarnings("unchecked")
    public static <T> T getBean(String name) throws BeansException {
        return (T) applicationContext.getBean(name);
    }

}