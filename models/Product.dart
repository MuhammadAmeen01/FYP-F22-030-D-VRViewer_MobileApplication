import 'package:flutter/material.dart';
import 'package:firebase_storage/firebase_storage.dart';
import 'package:firebase_database/firebase_database.dart';

class Product {
  final int id;
  final String title, description;
  final List<String> images;
  final List<Color> colors;
  final double rating, price;
  final bool isFavourite, isPopular;
  FirebaseDatabase database = FirebaseDatabase.instance;
  Product({
    required this.id,
    required this.images,
    required this.colors,
    this.rating = 0.0,
    this.isFavourite = false,
    this.isPopular = false,
    required this.title,
    required this.price,
    required this.description,
  });
}

// Our demo Products
Future<List<Product>> getDataList() async {
  // demoProducts=[];
  // if (demoProducts.length>0)
  //   {
  //     demoProducts.clear();
  //   }
  final databaseReference = FirebaseDatabase.instance.reference();
  List<dynamic> dataList = [];
  Set<Product> uniqueProducts = {};
  databaseReference.child('products').onValue.listen((event) {
    Map<dynamic, dynamic>? map = event.snapshot.value as Map<dynamic, dynamic>?;
    if (map != null) {
      map.forEach((key, value) {
        String image="";
        String color="";
        String Desc="";
        String Title="";
        for(var k in value.keys)
        {
          // print("key: $k,  ${value[k]}");
          if(k=="image")
            {
              image=value[k];
            }
          else if(k=="color"){
            color=value[k];
          }
          else if(k=="title")
            {
              Title=value[k];
            }
          else if(k=="description")
            {
              Desc=value[k];
            }
        }

        print(" $image, $color, $Title, $Desc");
        Product product = Product(
         id: 1,
         images: [
           image,image,image,image
         ],
         colors: [
           Color(0xFFF6625E),
           Color(0xFF836DB8),
           Color(0xFFDECB9C),
           Colors.white,
         ],
         title: Title,
         price: 64.99,
         description: Desc,
         rating: 4.8,
         isFavourite: true,
         isPopular: true,
       );
        // dataList.add(value);
        uniqueProducts.add(product);
      });
    }
    demoProducts = uniqueProducts.toList();
    // Do something with the dataList
    // for(var i=0;i<dataList.length;i++) {
    //   for (var k in dataList[i].keys) {
    //     print("Key : $k, value : ${dataList[k]}");
    //   }
    // }
    // for(var key in dataList[0].values){
    //   //get string for text widget
    //       print(Text(string));
    // }
    // print(dataList);
  });
  return demoProducts;
}
 List<Product> demoProducts=[];
// final demoProducts = <Product>[];
//[
//
//   Product(
//     id: 1,
//     images: [
//       "assets/images/ps4_console_white_1.png",
//       "assets/images/ps4_console_white_2.png",
//       "assets/images/ps4_console_white_3.png",
//       "assets/images/ps4_console_white_4.png",
//     ],
//     colors: [
//       Color(0xFFF6625E),
//       Color(0xFF836DB8),
//       Color(0xFFDECB9C),
//       Colors.white,
//     ],
//     title: "Wireless Controller for PS4™",
//     price: 64.99,
//     description: description,
//     rating: 4.8,
//     isFavourite: true,
//     isPopular: true,
//   ),
//   Product(
//     id: 2,
//     images: [
//       "assets/images/Image Popular Product 2.png",
//     ],
//     colors: [
//       Color(0xFFF6625E),
//       Color(0xFF836DB8),
//       Color(0xFFDECB9C),
//       Colors.white,
//     ],
//     title: "Nike Sport White - Man Pant",
//     price: 50.5,
//     description: description,
//     rating: 4.1,
//     isPopular: true,
//   ),
//   Product(
//     id: 3,
//     images: [
//       "assets/images/glap.png",
//     ],
//     colors: [
//       Color(0xFFF6625E),
//       Color(0xFF836DB8),
//       Color(0xFFDECB9C),
//       Colors.white,
//     ],
//     title: "Gloves XC Omega - Polygon",
//     price: 36.55,
//     description: description,
//     rating: 4.1,
//     isFavourite: true,
//     isPopular: true,
//   ),
//   Product(
//     id: 4,
//     images: [
//       "assets/images/wireless headset.png",
//     ],
//     colors: [
//       Color(0xFFF6625E),
//       Color(0xFF836DB8),
//       Color(0xFFDECB9C),
//       Colors.white,
//     ],
//     title: "Logitech Head",
//     price: 20.20,
//     description: description,
//     rating: 4.1,
//     isFavourite: true,
//   ),
// ];
//
// const String description =
//     "Wireless Controller for PS4™ gives you what you want in your gaming from over precision control your games to sharing …";
// // final ref = FirebaseDatabase.instance.ref();
// // final snapshot = await ref.child('users/$userId').get();
// // if (snapshot.exists) {
// // print(snapshot.value);
// // } else {
// // print('No data available.');
// // }