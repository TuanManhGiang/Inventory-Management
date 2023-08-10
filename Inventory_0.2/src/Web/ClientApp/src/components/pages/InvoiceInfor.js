import React, { Component } from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, DatePicker, Select } from 'antd';
import { useNavigate } from "react-router-dom";
import { WarehousesClient } from "../../web-api-client.ts";
const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 16,
    },
};


export default class  InvoiceInfor extends Component  {
    constructor(props) {
        super(props);
        this.state = {
            option: [],
            loading: true,
        }
    }
    async WarehousesData() {

        let client = new WarehousesClient();
        const data = await client.getAllWarehouses();
        const formattedOptions = data.map((warehouse) => ({
            value: warehouse.warehouseId, // Replace 'id' with the property name in your warehouse data that serves as the option value
            label: warehouse.warehouseName, // Replace 'name' with the property name in your warehouse data that serves as the option label
        }));

        this.setState({ option: formattedOptions, loading: false });
    }
    componentDidMount() {
        this.WarehousesData();
    }
    
    render() {
        const { option,loading } = this.state;
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
                        options={option}
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
    }

}
