import React from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button ,message} from 'antd';
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

 
const CreateProduct = () => {
    const navigate = useNavigate();
    const [form] = Form.useForm();
    const onFinish = async (values) => {
        try {
            let client = new ProductsClient();
            const data = await client.createProduct(values);
            console.log(data);
            message.success('Thêm sản phẩm thành công.')
            navigate("/AllProduct")
        } catch (error) {
            //handle api error
            message.error('some thing wrong.');
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
                    title: 'Sản Phẩm',
                },
                {
                    title: "Danh sách sản phẩm",
                },
                {
                    title: "Thêm sản phẩm",
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
                <Card title="Thông tin chung" size="large">
                    <Form.Item
                        name="productId"
                        label="Mã Sản Phẩm"
                        rules={[
                            {
                                required: true,
                            },
                        ]}
                    >
                        <Input />
                        </Form.Item>
                        <Form.Item
                            name="materialName"
                            label="Tên Sản Phẩm"
                            rules={[
                                {
                                    required: true,
                                    message: 'Please input the material name',
                                },
                            ]}
                        >
                            <Input />
                        </Form.Item>
                </Card>
                <Card title="Thuộc Tính Sản Phẩm" size="small">

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
                {/*<Card title="Card" size="small">*/}
                {/*    <p>Card content</p>*/}
                {/*    <p>Card content</p>*/}
                {/*</Card>*/}
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
export default CreateProduct;