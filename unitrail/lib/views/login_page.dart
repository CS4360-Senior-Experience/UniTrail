import 'package:flutter/material.dart';
import 'package:unitrail/views/Components/text_field.dart';
import 'package:unitrail/views/Widgets/my_button.dart';
import 'package:unitrail/views/home.dart';
import 'package:expandable_bottom_bar/expandable_bottom_bar.dart';
import 'Components/tile.dart';

class LoginPage extends StatelessWidget {
  final emailController = TextEditingController();
  final passwordController = TextEditingController();

  void saveInformation() {
    print(emailController.text);
    print(passwordController.text);
  }

  @override
  Widget build(BuildContext context) {
    return DecoratedBox(
      decoration: BoxDecoration(
        image: DecorationImage(
            image: AssetImage('assets/images/Tiv.jpg'),
            fit: BoxFit.cover,
            colorFilter: ColorFilter.mode(Colors.black54, BlendMode.darken)
            //colorFilter: ColorFilter.mode(Colors.black54, BlendMode.darken)
            ),
      ),
      child: Column(
        children: [
          Divider(height: 60),
          Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Tile(imagePath: 'assets/images/Logo1.png'),
            ],
          ),
          Divider(height: 200),

          Textfield(
              controller: emailController,
              hintText: 'Email',
              obscureText: false,
              icon: Icon(Icons.email)),
          //Divider(height: 2),
          Textfield(
            controller: passwordController,
            hintText: 'Enter Password',
            obscureText: true,
            icon: Icon(Icons.password),
          ),
          MyButton(
            title: 'Login',
            color: Colors.white,
            onPressed: () {
              Navigator.push(context, MaterialPageRoute(builder: (context) {
                return MaterialApp(
                    home: DefaultBottomBarController(child: HomeScreen()));
              }));
            },
          )
        ],
      ),
    );
  }
}
