import 'package:flutter/material.dart';
import 'package:sizer/sizer.dart';
import 'package:unitrail/views/Components/GridDashboard.dart';

class SettingsScreen extends StatelessWidget {
  const SettingsScreen({super.key});

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
        ));
  }
}
