import React from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, Col, Row } from 'antd';
import { useNavigate } from "react-router-dom";
import { ProductsClient } from "../../web-api-client.ts";
import InvoiceInfor from './InvoiceInfor';
import SupplierInfor from './SupplierInfor';
const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 16,
    },
};


const ListImport = () => {
    const navigate = useNavigate();
    const [form] = Form.useForm();
    const onFinish = async (values) => {
        try {
            //let client = new ProductsClient();
            //const data = await client.createProduct(values);
            console.log(values);

            navigate("/AllProduct")
        } catch (error) {
            //handle api error
            console.error('Error:', error);
        }

    };
    const onReset = () => {
        navigate("/AllProduct")
    };


    return (
        <div>
            <Breadcrumb
                style={{
                    margin: "0 16px",
                    fontSize: "14px",
                    margin: '16px'
                }}
                items={[
                    {
                        title: 'Nhập Hàng',
                    },
                    {
                        title: "Danh sách đơn nhập hàng",
                    },
                    {
                        title: "Thêm đơn nhập hàng"
                    },

                ]}
            />
            <Form onFinish={onFinish}>
                <Space
                    direction="vertical"
                    size="middle"
                    style={{
                        display: 'flex',
                        margin: '16px',
                    }}
                >
                    <Space
                        direction="horizontal"
                        size="middle"

                    >
                        <Row gutter={16}>
                        <Col span={9}>
                            <InvoiceInfor />
                        </Col>
                        <Col span={15}>
                            <SupplierInfor />
                            </Col>
                        </Row>
                    </Space>
                    <Card title="Thông tin sản phẩm" size="small">

                        <Form.Item
                            name="unit"
                            label="Unit"
                            rules={[
                                {
                                    required: true,
                                    message: 'Please input the unit',
                                },
                            ]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            name="type"
                            label="Type"
                            rules={[
                                {
                                    required: true,
                                    message: 'Please input the type',
                                },
                            ]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            name="color"
                            label="Color"
                            rules={[
                                {
                                    required: true,
                                    message: 'Please input the color',
                                },
                            ]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            name="size"
                            label="Size"
                            rules={[
                                {
                                    required: true,
                                    message: 'Please input the size',
                                },
                            ]}
                        >
                            <Input />
                        </Form.Item>
                    </Card>
                    
                </Space>
                <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                    <Form.Item>
                        <Button
                            type="primary"
                            ghost
                            size="large"
                            htmlType="submit"
                            style={{ width: '150px', marginRight: '10px' }}
                        >
                            Lưu
                        </Button>
                        <Button
                            type="primary"
                            size="large"
                            onClick={onReset}
                            style={{ width: '150px' }}
                        >
                            Thoát
                        </Button>
                    </Form.Item>
                </div>
            </Form>
        </div>
    )
};
export default ListImport;