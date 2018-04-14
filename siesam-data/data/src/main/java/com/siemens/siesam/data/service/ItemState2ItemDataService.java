package com.siemens.siesam.data.service;

import com.siemens.mvp.thrift.thrift_client.ItemData;
import com.siemens.siesam.data.DataMain;
import org.jinterop.dcom.common.JIException;
import org.openscada.opc.lib.da.ItemState;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

/**
 * zhuo.chen@siemens.com
 * Created by Chen Zhuo on 2016/7/26.
 */
@Service("ItemState2ItemDataService")
public class ItemState2ItemDataService {

    private static final Logger LOGGER = LoggerFactory.getLogger(DataMain.class);

    public ItemData getItemData(ItemState itemState){

        ItemData afterTransform = new ItemData();

        try {
            afterTransform.setValue(itemState.getValue().getObject().toString());
            afterTransform.setTimeStamp(itemState.getTimestamp().getTimeInMillis());
            afterTransform.setQuality(itemState.getQuality().intValue());
        } catch (JIException e) {
            LOGGER.error("Parsing result error. JIException: "+e.getMessage()+". error code: "+e.getErrorCode());
        }

        return afterTransform;
    }

}
