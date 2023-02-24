import 'package:expandable_bottom_bar/expandable_bottom_bar.dart';
import 'package:flutter/material.dart';
import 'package:sizer/sizer.dart';
import 'package:unitrail/views/Components/GridDashboard.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFfcf7f8),
      appBar: AppBar(
          title: Image.asset(
            "assets/images/team_logo.png",
            fit: BoxFit.contain,
            height: 5.h,
          ),
          toolbarHeight: 7.h,
          backgroundColor: const Color(0xFFa31621),
          actions: [
            TextButton(
              onPressed: () {},
              // ignore: sort_child_properties_last
              child: Icon(
                Icons.logout_rounded,
                color: Color(0xFFfcf7f8),
              ),
            )
          ]),
      body: Column(
        children: <Widget>[GridDashboard()],
      ),
      //
      // Lets use docked FAB for handling state of sheet
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: GestureDetector(
        //
        // Set onVerticalDrag event to drag handlers of controller for swipe effect
        onVerticalDragUpdate: DefaultBottomBarController.of(context).onDrag,
        onVerticalDragEnd: DefaultBottomBarController.of(context).onDragEnd,
        child: FloatingActionButton.extended(
          label: AnimatedBuilder(
            animation: DefaultBottomBarController.of(context).state,
            builder: (context, child) => Row(
              children: [
                Text(
                  DefaultBottomBarController.of(context).isOpen
                      ? "Pull"
                      : "Pull",
                ),
                const SizedBox(width: 4.0),
                AnimatedBuilder(
                  animation: DefaultBottomBarController.of(context).state,
                  builder: (context, child) => Transform(
                    alignment: Alignment.center,
                    transform: Matrix4.diagonal3Values(
                      1,
                      DefaultBottomBarController.of(context).state.value * 2 -
                          1,
                      1,
                    ),
                    child: child,
                  ),
                  child: const RotatedBox(
                    quarterTurns: 1,
                    child: Icon(
                      Icons.chevron_right,
                      size: 20,
                    ),
                  ),
                ),
              ],
            ),
          ),
          elevation: 1,
          backgroundColor: const Color(0xFFfcf7f8),
          foregroundColor: const Color(0xFFa31621),
          //
          //Set onPressed event to swap state of bottom bar
          onPressed: () => DefaultBottomBarController.of(context).swap(),
        ),
      ),
      bottomNavigationBar: BottomExpandableAppBar(
        horizontalMargin: 16,
        bottomAppBarColor: const Color(0xff78c091),
        shape: const AutomaticNotchedShape(
            RoundedRectangleBorder(), StadiumBorder(side: BorderSide())),
        expandedBackColor: const Color(0xFFfcf7f8),
        expandedBody: const Center(
          child: Text("Hello world!"),
        ),
        bottomAppBarBody: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Row(
            mainAxisSize: MainAxisSize.max,
            children: const <Widget>[
              Expanded(
                child: Text(
                  "Foo",
                  textAlign: TextAlign.center,
                ),
              ),
              Spacer(
                flex: 2,
              ),
              Expanded(
                child: Text(
                  "Bar",
                  textAlign: TextAlign.center,
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
