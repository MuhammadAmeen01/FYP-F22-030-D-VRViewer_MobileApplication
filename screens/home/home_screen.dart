import 'package:flutter/material.dart';
import 'package:shop_app/components/coustom_bottom_nav_bar.dart';
import 'package:shop_app/enums.dart';

import '../../models/Product.dart';
import 'components/body.dart';

class HomeScreen extends StatelessWidget {
  static String routeName = "/home";
  @override
  Widget build(BuildContext context) {
    bool hasDuplicates = false;

    for (int i = 0; i < demoProducts.length; i++) {
      for (int j = i + 1; j < demoProducts.length; j++) {
        if (demoProducts[i].images[0] == demoProducts[j].images[0]) {
          hasDuplicates = true;
          break;
        }
      }
      if (hasDuplicates) {
        break;
      }
    }

    if (hasDuplicates) {
      print("Duplicates found");
    } else {
      print("No duplicates found");
    }

    getDataList();
    demoProducts = demoProducts.toSet().toList();
    return Scaffold(

      body: Body(),
      bottomNavigationBar: CustomBottomNavBar(selectedMenu: MenuState.home),
    );
  }
}
