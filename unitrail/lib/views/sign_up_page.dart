import 'package:flutter/material.dart';
import 'package:unitrail/views/Components/text_field.dart';
import 'package:unitrail/views/Widgets/my_button.dart';

import 'Components/tile.dart';

class SignUpPage extends StatelessWidget {
  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();
  final passwordController = TextEditingController();
  final emailController = TextEditingController();

  void saveInformation() {
    print(firstNameController.text);
    print(lastNameController.text);
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
              controller: firstNameController,
              hintText: 'First Name',
              obscureText: false,
              icon: Icon(Icons.person)),
          //Divider(height: 2),
          Textfield(
              controller: lastNameController,
              hintText: 'Last Name',
              obscureText: false,
              icon: Icon(Icons.person)),
          //Divider(height: 2),
          Textfield(
              controller: emailController,
              hintText: 'Enter email',
              obscureText: false,
              icon: Icon(Icons.email)),
          Textfield(
            controller: passwordController,
            hintText: 'Enter Password',
            obscureText: false,
            icon: Icon(Icons.password),
          ),
          MyButton(title: 'Sign Up', color: Colors.white, onPressed: null)
        ],
      ),
    );
  }
}
