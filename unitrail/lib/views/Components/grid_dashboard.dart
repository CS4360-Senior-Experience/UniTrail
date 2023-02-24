import 'package:flutter/material.dart';
import 'package:unitrail/views/my_classes.dart';
import 'package:unitrail/views/navigate.dart';
import 'package:unitrail/views/search_classes.dart';
import 'package:unitrail/views/settings.dart';

// ignore: must_be_immutable
class GridDashboard extends StatelessWidget {
  Items item1 = Items(
      title: "Navigate",
      routeName: MaterialPageRoute(builder: (context) => NavigateScreen()));

  Items item2 = Items(
      title: "My Classes",
      routeName: MaterialPageRoute(builder: (context) => ClassesScreen()));
  Items item3 = Items(
      title: "Search Classrooms",
      routeName: MaterialPageRoute(builder: (context) => SearchScreen()));
  Items item4 = Items(title: "Calendar (Beta)", routeName: null);
  Items item5 = Items(
      title: "Settings",
      routeName: MaterialPageRoute(builder: (context) => SettingsScreen()));
  Items item6 = Items(title: "AR Debug", routeName: null);

  @override
  Widget build(BuildContext context) {
    List<Items> myList = [item1, item2, item3, item4, item5, item6];
    var color = 0xFFfcf7f8;
    return Flexible(
      child: GridView.count(
          childAspectRatio: 1.0,
          padding: EdgeInsets.all(20),
          crossAxisCount: 2,
          crossAxisSpacing: 18,
          mainAxisSpacing: 18,
          children: myList.map((data) {
            return Container(
                decoration: BoxDecoration(
                    border: Border.all(color: Color(0xFFa31621)),
                    color: Color(color),
                    borderRadius: BorderRadius.circular(15)),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    ElevatedButton(
                        // ignore: sort_child_properties_last
                        child: Text(data.title),
                        onPressed: () {
                          Navigator.push(context, data.routeName);
                        },
                        style: ElevatedButton.styleFrom(
                            backgroundColor: const Color(0xff78c091),
                            shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(20))))
                  ],
                ));
          }).toList()),
    );
  }
}

class Items {
  String title;
  // ignore: prefer_typing_uninitialized_variables
  final routeName;
  Items({required this.title, required this.routeName});
}
