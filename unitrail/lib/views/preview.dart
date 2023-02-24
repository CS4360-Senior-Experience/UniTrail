import 'package:flutter/material.dart';
import 'package:flutter_unity_widget/flutter_unity_widget.dart';

class UnityDemoScreen extends StatefulWidget {

  const UnityDemoScreen({Key? key}) : super(key: key);

  @override
  _UnityDemoScreenState createState() => _UnityDemoScreenState();
}

class _UnityDemoScreenState extends State<UnityDemoScreen>{
  static final GlobalKey<ScaffoldState> _scaffoldKey =
      GlobalKey<ScaffoldState>();
  late UnityWidgetController _unityWidgetController;
  @override
  void initState() {
    super.initState();
    setNavigationTarget("","");
  }


  @override
  Widget build(BuildContext context) {

    return Scaffold(
      key: _scaffoldKey,
      body: SafeArea(
        bottom: false,
          child: Container(
            color: Colors.amber,
            child: UnityWidget(
              onUnityCreated: onUnityCreated,
            ),
          ),
        ),
    );
  }
  // Communcation from Flutter to Unity
  void setNavigationTarget(String startLocation,String endLocation) async {
    await _unityWidgetController.postMessage(
      'PathRenderer',
      'SetNagivationTarget',
      {startLocation,endLocation}
      
    );
  }
  // Callback that connects the created controller to the unity controller
  void onUnityCreated(controller) {
    _unityWidgetController = controller;
  }
}