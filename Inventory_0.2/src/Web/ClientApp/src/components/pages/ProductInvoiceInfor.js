import React, { Component } from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, DatePicker, Select } from 'antd';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
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


export default class ProductInvoiceInfor extends Component {
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
        const { option, loading } = this.state;
        return (
            <Card title="Thông tin sản phẩm" size="small">
                <Form.List name="users">
                    {(fields, { add, remove }) => (
                        <>
                            {fields.map(({ key, name, ...restField }) => (
                                <Space
                                    key={key}
                                    style={{
                                        display: 'flex',
                                        marginBottom: 8,
                                    }}
                                    align="baseline"
                                >
                                    <Form.Item
                                        {...restField}
                                        name={[name, 'first']}
                                        rules={[
                                            {
                                                required: true,
                                                message: 'Missing first name',
                                            },
                                        ]}
                                    >
                                        <Input placeholder="First Name" />
                                    </Form.Item>
                                    <Form.Item
                                        {...restField}
                                        name={[name, 'last']}
                                        rules={[
                                            {
                                                required: true,
                                                message: 'Missing last name',
                                            },
                                        ]}
                                    >
                                        <Select
                                            showSearch
                                            style={{ width: 400 }}
                                            placeholder="Search to Select"
                                            optionFilterProp="children"
                                            filterOption={(input, option) => (option?.label ?? '').includes(input)}
                                            filterSort={(optionA, optionB) =>
                                                (optionA?.label ?? '').toLowerCase().localeCompare((optionB?.label ?? '').toLowerCase())
                                            }
                                            options={option}

                                           /* onChange={handleSelect}*/

                                        />
                                    </Form.Item>
                                    <MinusCircleOutlined onClick={() => remove(name)} />
                                </Space>
                            ))}
                            <Form.Item>
                                <Button type="dashed" onClick={() => add()} block icon={<PlusOutlined />}>
                                    Add field
                                </Button>
                            </Form.Item>
                        </>
                    )}
                </Form.List>
            </Card>
        )
    }

}
