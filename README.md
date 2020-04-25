# bonafoot-dotnet
Soccer game based on Elifoot (http://www.elifoot.com/)  
Teams and players are automatically generated with generic names and colors.  
![Bonafoot](https://github.com/cbonatti/bonafoot-dotnet/blob/master/bonafoot.gif)  

### Getting Started
- You will need a MongoDb instance running
- Your appsettings.json should be like this:
<pre>
{
  "MongoDB": {
    "Database": "YOUR_DATABASE",
    "Host": "YOUR_HOST",
    "Port": 0,
    "User": "YOUR_USER",
    "Password": "YOUR_PASSWORD"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
</pre>

### Game Field  
<pre>
|-- HOME  FIELD ---|--- GUEST  FIELD --|  
                   |
+--------------------------------------+ 
|        |         |         |         | 
|  DEF   |  MID    |   MID   |   DEF   |
|        |         |         |         |
                   |
                   |
                CENTER  
</pre>
#### The ball can be in the following positions:  
- Home Defense
- Home Midfield
- Center
- Guest Midfield
- Guest Defense

### Ball Moviment
The ball moves according the position it is.
#### When Center: 
The average strength of midfielders players of both teams is calculated.
- Home is greater than Guest => Ball move to Guest Midfield
- Guest is greater => Ball move to Home Midfield
- They are equal => Ball stays at Center

#### When Midfield: 
The average strength of midfielders players of attacking team and defenders players of defending team is calculated.
> _When the ball is on Guest Midfield => Home Team is the Attacking Team and Guest Team is the Defending one_  

- Midfielder is greater than Defender => Ball move to Defender field
- Defender is greater => Ball move to Center
- They are equal => Ball stays at Midfield

#### When Defense: 
The average strength of strickers players of attacking team and goalkeeper player of defending team is calculated.
- Stricker is greater than Goalkeeper => Attacking team score and ball move to Defender field
- Goalkeeper is greater => Ball move to Midfield
- They are equal => Ball stays at Defense

**For each Combat(Home vs Guest team) a factor is applyied to players strength to force results not to be the same**
