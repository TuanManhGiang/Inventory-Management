

import React, { useState } from 'react';
import { DownOutlined } from '@ant-design/icons';
import { Button, Col, Form, Input, Row, Select, Space, theme } from 'antd';
import { ProductTable } from './ProductTable';
const { Option } = Select;
const AdvancedSearchForm = () => {
    const { token } = theme.useToken();
    const [form] = Form.useForm();
    const [expand, setExpand] = useState(false);
    const formStyle = {
        maxWidth: 'none',
        background: token.colorFillAlter,
        borderRadius: token.borderRadiusLG,
        padding: 24,
    };
    const getField = ['Tên',"Loại","nhà cung cấp"]
    const getFields = () => {
        const count = expand ? 3 : 3;
        const children = [];
        for (let i = 0; i < count; i++) {
            children.push(
                <Col span={8} key={i}>
                    {i % 3 !== 1 ? (
                        <Form.Item
                            name={getField[i]}
                            label={getField[i]}
                            rules={[
                                {
                                    required: false,
                                    message: 'Input something!',
                                },
                            ]}
                        >
                            <Input placeholder={getField[i]} />
                        </Form.Item>
                    ) : (
                        <Form.Item
                                name={getField[i]}
                                label={getField[i]}
                            rules={[
                                {
                                    required: false,
                                    message: 'Select something!',
                                },
                            ]}
                            initialValue="1"
                        >
                            <Select>
                                <Option value="1">
                                    a
                                </Option>
                                <Option value="2">222</Option>
                            </Select>
                        </Form.Item>
                    )}
                </Col>,
            );
        }
        return children;
    };
    const onFinish = (values) => {
        console.log('Received values of form: ', values);
    };
    return (
        <Form form={form} name="advanced_search" style={formStyle} onFinish={onFinish}>
            <Row gutter={24}>{getFields()}</Row>
            <div
                style={{
                    textAlign: 'right',
                }}
            >
                <Space size="small">
                    <Button type="primary" htmlType="submit">
                        Search
                    </Button>
                    <Button
                        onClick={() => {
                            form.resetFields();
                        }}
                    >
                        Clear
                    </Button>
              
                </Space>
            </div>
        </Form>
    );
};
const ListProduct = () => {
    const { token } = theme.useToken();
    const listStyle = {
        lineHeight: '200px',
        textAlign: 'center',
        background: token.colorFillAlter,
        borderRadius: token.borderRadiusLG,
        marginTop: 8,
    };
    return (
        <>
            <AdvancedSearchForm />
            <div style={listStyle}><ProductTable></ProductTable></div>
        </>
    );
};

export default ListProduct;