import 'package:flutter/material.dart';
import 'package:shop_app/Catalog/ProductItemWidget.dart';
import 'package:shop_app/models/Product.dart';
class ProductCatalogScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Product Catalog")),
      body: ListView.builder(
        itemCount: demoProducts.length,
        itemBuilder: (context, index) {
          final product = demoProducts[index];
          return ProductItemWidget(product: product);
        },
      ),
    );
  }
}
