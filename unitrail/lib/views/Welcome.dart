//import 'package:flutter_svg/flutter_svg.dart';

import 'package:flutter/material.dart';
import 'package:namer_app/views/Homescreen.dart';
import 'package:namer_app/views/Widgets/UniButton.dart';

class Welcome extends  StatelessWidget {
  
  @override
  Widget build(BuildContext context){
    return Stack(
      children: [
        Scaffold(
          appBar: AppBar(
            title: Image.asset('assets/images/logo.png',fit: BoxFit.cover),
          ),
        ),
        Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('assets/images/Tiv.jpeg'),
            fit:  BoxFit.cover
            )
        )
      ),
      Center(
        child: Column(
          
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget> [
            UniBotton(title: 'Sign in', color: Color.fromARGB(255, 129, 22, 14)
            , onPressed: (){}),
            SizedBox(height: 10,),
            UniBotton(title: 'Guest', 
              color: Color.fromARGB(255, 129, 22, 14), 
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) {
                      return const HomeScreen();
                    }
                  )
                );
              }
            ),
          ],
        ),
      )
      ]
    );
  }
}

 class BigCard extends StatelessWidget {
  const BigCard({
    Key? key,
    required this.value,
  }) : super(key: key);
  final int value;

  @override
  Widget build(BuildContext context) {
    var theme = Theme.of(context);
    var style = theme.textTheme.displaySmall!.copyWith(color: theme.colorScheme.onPrimary);
    return Card(

      shape:RoundedRectangleBorder(borderRadius: BorderRadius.circular(30)),
      color: theme.colorScheme.primary,
      child: Padding(
        
        padding: const EdgeInsets.all(15.0),
        child: Text(value.toString(), style: style),
      ),
    );
  }
}