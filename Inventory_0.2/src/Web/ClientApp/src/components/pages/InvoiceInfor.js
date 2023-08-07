import React from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, DatePicker, Select } from 'antd';
import { useNavigate } from "react-router-dom";
import { ProductsClient } from "../../web-api-client.ts";
const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 16,
    },
};


const InvoiceInfor = () => {
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


    return (
        <Card title="Thông tin đơn đặt hàng" size="large">
            <Form.Item
                name="WarehouseId"
                label="Chi nhánh"
                rules={[
                    {
                        required: true,
                    },
                ]}
            >
                <Select
                    showSearch
                   // style={{ width: 200 }}
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
            </Form.Item>
            <Form.Item
                name="EmployeeId"
                label="Nhân viên"
                rules={[
                    {
                        required: true,
                        message: 'Please input the material name',
                    },
                ]}
            >
                <Select
                    showSearch
                   // style={{ width: 200 }}
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
            </Form.Item>
            <Form.Item
                name="ImportDate"
                label="Ngày nhập"
                rules={[
                    {
                        required: true,
                        message: 'Please input the material name',
                    },
                ]}
            >
                <DatePicker
                    cellRender={(current, info) => {
                        if (info.type !== 'date') return info.originNode;
                        const style = {};
                        if (current.date() === 1) {
                            style.border = '1px solid #1677ff';
                            style.borderRadius = '50%';
                        }
                        return (
                            <div className="ant-picker-cell-inner" style={style}>
                                {current.date()}
                            </div>
                        );
                    }}
                />
            </Form.Item>
        </Card>
    )
};
export default InvoiceInfor;