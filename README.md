# golfathonProgram
Multi-form Windows application that connects to a database written in Visual Basic for IT 102 (Programming 2) course at Cincinnati State

IT 102
Final Project - Golf-a-thon

Problem: You have been asked to write a program for a local charity that has an annual golf-a-thon to raise money. The event has golfers sign up and then gather sponsors 
to pay them for playing in the event. The program needs to be able to add, update(edit) and delete golfers. It also needs to be able to add, update(edit) and delete sponsors.
It should also allow for a golfer to be added to an event and to add sponsorships to the golfer. Don’t forget when you add a golfer in for the current year you will have to
add them into the TGolferEventYears. There are several places you will have to add records to make everything work correctly. Make sure you have this in place. 
The final piece is for you to have the program pull up the sponsors and the amount pledged by each sponsor for a golfer in a given event/year. This should also display a
total amount for the golfer in a given event/year.
Instructions: 
1.	Use the database script that is provided with FK’s and limited data already entered in for you. You need to create stored procedures for each insert, delete and update
in your program. You need to create views as needed to pull data from the DB to use in your program. You need to add data as needed for your individual project. The tables 
are as follows
TEventYears
TGenders
TGolferEventYears
TGolferEventYearSponsors
TGolfers
TPaymentTypes
TShirtSizes
TSponsors
TSponsorTypes
2.	Use separate forms to add both sponsors and golfers. You can use a search form (combo box as we have done in assignments) to pull the information for a sponsor or golfer
and then edit or delete using that form.
3.	Create a form that will add a golfer to an event and also allow for a sponsorship to be added to that golfer.
4.	Do not allow any deletions without prompting if the user is sure they wish to delete.
5.	Avoid global variables, pass information or use classes, collections, and/or structures to share data.
6.	If you have any questions, please email your instructor.
7.	If you have any issues a good resource is http://www.w3schools.com/
8.	Any new functionality should use a stored procedure. Any items using sql statements in VB from previous assignments do not need to be updated to stored procedures.

Rubric:
A lot of the functionality of the final project was completed in assignments 2, 3, 7 & 8. This rubric takes into consideration those items are in correct working order.

1.	Adding functionality to add a sponsor. (25 pts.)
2.	Adding functionality to add a sponsor to a golfer for an event with all items required for TGolferEventYearSponsors table. (45 pts.)
3.	Adding functionality to show aggregates for the following:
a.	Golfer total by event (10 pts.)
b.	Event totals (10 pts.)
c.	Sponsor total by event (10 pts.)
