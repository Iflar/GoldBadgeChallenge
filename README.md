# GoldBadgeChallenge
This solution contains a number of console applications (challenges) that incorporate the repository pattern.



Challenge: 1
The first console application that I chose was the Cafe challenge 

In this challenge you are tasked to create a fictional cafe that has a few menu items each with their own price and set of ingredients.

To accomplish this task I simply made a class for the menu item and added that object to a list (_menuDirectory) 

this is the menu itself. Of course the customer needs the ability to place an order

for this aspect of the challenge, I created a new list (_orderDirectory) this list is intended to hold one object at a time,

that being: the customer's chosen menu item. Finally, the customer needs the ability to view all the ingredients of a particular menu item 

this was definitely something new to me, as I needed to display a list of enums (that list being a property of the menu item).

In the end I’d say it all works as intended - indeed I glossed over a few of the finer details, but I’ll let the code do the talking.



Challenge: 2
The second console app I created was the Komodo customer greeting challenge

This challenge is fairly straightforward, basically a customer needs to be labeled as ‘potential’, ‘current’, and ‘past’. 

An email is sent out to the customer that corresponds with their “type”.

To accomplish this I gave the Customer class a property of type: DateTime, 

this represented their last active date, if the date of the customer was greater than a particular (arbitrary) amount of time,

they would be labeled as ‘past’. If the date was less than that factor, they would be labeled as ‘current’, and of course, if the date active was null

they would be labeled as ‘potential’.



	Challenge: 3
The third Console application that was developed was the Smart Insurance challenge. 

this app needed the functionality to calculate a drivers monthly premium based on driving habits

for the most part this challenge is quite open ended as to how that feat was accomplished, so I decided to simply give the Class of Driver two list properties

one for good habits, and another for bad habits. Then I add a random number of habits to each list and calculate the premium based on the number of habits

for each good habit, the premium is reduced by 20%, and raised bt 30% for each bad habit.
