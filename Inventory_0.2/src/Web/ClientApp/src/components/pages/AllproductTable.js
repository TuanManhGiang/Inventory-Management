import { Table, Button, Result } from "antd";
import { ProductsClient } from "../../web-api-client.ts";
import {  Component } from "react";

export class AllProductTable extends Component {
    static displayName = AllProductTable.name;

    constructor(props) {
        super(props);
        this.state = {
            productList: [],
            loading: true,
            columns: [
                {
                    title: "Mã kho",
                    dataIndex: "wareHouseId",
                },
                {
                    title: "Mã sản phẩm",
                    dataIndex: "productId",
                },
                {
                    title: "Tên sản phẩm", // Added title for "materialName"
                    dataIndex: "materialName", // Corresponding dataIndex for "materialName"
                },
                {
                    title: "Đơn vị", // Added title for "unit"
                    dataIndex: "unit", // Corresponding dataIndex for "unit"
                },
                {
                    title: "Loại", // Added title for "type"
                    dataIndex: "type", // Corresponding dataIndex for "type"
                },
                {
                    title: "Màu", // Added title for "color"
                    dataIndex: "color", // Corresponding dataIndex for "color"
                },
                {
                    title: "Kích thước", // Added title for "size"
                    dataIndex: "size", // Corresponding dataIndex for "size"
                },
                {
                    title: "Mã kệ", // Added title for "shelfId"
                    dataIndex: "shelfId", // Corresponding dataIndex for "shelfId"
                },
                {
                    title: "Mã tủ", // Added title for "cabinetId"
                    dataIndex: "cabinetId", // Corresponding dataIndex for "cabinetId"
                },
                {
                    title: "Số lượng tồn", // Added title for "quantityOnHand"
                    dataIndex: "quantityOnHand", // Corresponding dataIndex for "quantityOnHand"
                },
            ],
        };
    }

    componentDidMount() {
        this.ProductsData();
    }

    static renderProductsTable(productList, columns) {
        return (
            <div>
                <Table columns={columns} dataSource={productList} scroll={{ y: 300 }} pagination={true}>

                </Table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading ? (
            <Result
                status="404"
                title="No Data"
                subTitle="Sorry, you haven't data."
                
            />
        ) : (
            AllProductTable.renderProductsTable(
                this.state.productList,
                this.state.columns
            )
        );

        return <div>{contents}</div>;
    }

    async ProductsData() {
        
        let client = new ProductsClient();
        const data = await client.getAllProducts();

        this.setState({ productList: data, loading: false });
    }

    //async populateWeatherDataOld() {
    //  const response = await fetch("weatherforecast");

    //  const data = await response.json();
    //    this.setState({ productList: data, loading: false });
    //}
}
