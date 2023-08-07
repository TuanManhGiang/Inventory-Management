﻿import React, { useState } from 'react';
import { Button, Modal } from 'antd';
const AddSupplier = () => {
    const [open, setOpen] = useState(false);
   // const [confirmLoading, setConfirmLoading] = useState(false);
    const [modalText, setModalText] = useState('Content of the modal');
    const showModal = () => {
        setOpen(true);
    };
    const handleOk = () => {
        setModalText('The modal will be closed after two seconds');
       // setConfirmLoading(true);
        setTimeout(() => {
            setOpen(false);
            //setConfirmLoading(false);
        }, 2000);
    };
    const handleCancel = () => {
        console.log('Clicked cancel button');
        setOpen(false);
    };
    return (
        <>

            <Modal
                title="Thêm Nhà cung cấp"
                open={open}
                onOk={handleOk}
                //confirmLoading={confirmLoading}
                onCancel={handleCancel}
            >
                
            </Modal>
            <Button type="primary" onClick={showModal}>
                thêm nhà cung cấp
            </Button>
        </>
    );
};
export default AddSupplier;