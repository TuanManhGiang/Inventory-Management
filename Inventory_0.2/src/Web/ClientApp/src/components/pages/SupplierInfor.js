import React, { useState } from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, DatePicker, Select, Descriptions, Modal } from 'antd';
import { useNavigate } from "react-router-dom";
import { ProductsClient } from "../../web-api-client.ts";



const SupplierInfor = () => {
    //const navigate = useNavigate();
    //const [form] = Form.useForm();
    //const onFinish = async (values) => {
    //    try {
    //        let client = new ProductsClient();
    //        const data = await client.createProduct(values);
    //        console.log(data);

    //        navigate("/AllProduct")
    //    } catch (error) {
    //        //handle api error
    //        console.error('Error:', error);
    //    }

    //};
    //const onReset = () => {
    //    navigate("/AllProduct")
    //};
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
        <Card title="Thông tin nhà cung cấp" size="large">
        
            <Form.Item
                name="SupplierId"
               
                rules={[
                    {
                        required: true,
                    },
                ]}
            >
                <Modal
                    title="Thêm Nhà cung cấp"
                    open={open}
                    onOk={handleOk}
                    //confirmLoading={confirmLoading}
                    onCancel={handleCancel}
                >

                </Modal>

                <Select
                    showSearch
                    style={{ width: 400 }}
                    placeholder="Search to Select"
                    optionFilterProp="children"
                    filterOption={(input, option) => (option?.label ?? '').includes(input)}
                    filterSort={(optionA, optionB) =>
                        (optionA?.label ?? '').toLowerCase().localeCompare((optionB?.label ?? '').toLowerCase())
                    }
                    options={[
                        {
                            value: '1',
                            label: 'Not Identified',
                        },
                        {
                            value: '2',
                            label: 'Closed',
                        },
                        {
                            value: '3',
                            label: 'Communicated',
                        },
                        {
                            value: '4',
                            label: 'Identified',
                        },
                        {
                            value: '5',
                            label: 'Resolved',
                        },
                        {
                            value: '6',
                            label: 'Cancelled',
                        },
                    ]}

                />
                <Button type="primary" onClick={showModal}>
                    thêm nhà cung cấp
                </Button>
                  
                
                <Descriptions title="Thông tin nhà cung cấp" />
            </Form.Item>

        </Card>
    )
};
export default SupplierInfor;