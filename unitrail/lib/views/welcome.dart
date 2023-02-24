import 'package:flutter/material.dart';
import 'package:unitrail/views/home.dart';
import 'package:unitrail/views/login_page.dart';
import 'package:unitrail/views/sign_up_page.dart';
import 'package:unitrail/views/Widgets/my_button.dart';
import 'Components/tile.dart';
import 'package:unitrail/views/navigate.dart';

class Welcome extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return DecoratedBox(
      decoration: BoxDecoration(
        image: DecorationImage(
            image: AssetImage('assets/images/Tiv.jpg'),
            fit: BoxFit.cover,
            colorFilter: ColorFilter.mode(Colors.black54, BlendMode.darken)),
      ),
      child: Column(
        children: [
          Divider(height: 60),
          Row(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Tile(imagePath: 'assets/images/Logo1.png'),
            ],
          ),
          Divider(height: 300),
          Text(
            "Welcome!",
            textAlign: TextAlign.start,
            overflow: TextOverflow.ellipsis,
            style: TextStyle(
                decoration: TextDecoration.none,
                color: Color(0xFFFCF7F8),
                fontWeight: FontWeight.bold,
                fontSize: 40),
          ),
          Divider(height: 100),
          MyButton(
            title: 'Login',
            color: Colors.white,
            onPressed: () {
              Navigator.push(context, MaterialPageRoute(builder: (context) {
                return LoginPage();
              }));
            },
          ),
          Divider(height: 10),
          MyButton(
            title: 'Guest',
            color: Colors.white,
            onPressed: () {
              Navigator.push(context, MaterialPageRoute(builder: (context) {
                return NavigateScreen();
              }));
            },
          ),
          Divider(height: 10),
          MyButton(
              title: 'Register',
              color: Colors.white,
              onPressed: () {
                Navigator.push(context, MaterialPageRoute(builder: (context) {
                  return SignUpPage();
                }));
              }),
        ],
      ),
    );
  }
}
