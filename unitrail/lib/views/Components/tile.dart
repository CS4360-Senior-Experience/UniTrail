
import 'package:flutter/material.dart';

class Tile extends StatelessWidget{
  final String imagePath;
  const Tile({
    super.key,
    required this.imagePath  
  });
  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: Border.all(color: Colors.white),
        borderRadius: BorderRadius.circular(12),
        color: Color.fromARGB(255, 153, 97, 93)
      ),
      height: 40,
      child: Image.asset(imagePath),
    );
    // TODO: implement build
    //throw UnimplementedError();
  }
}