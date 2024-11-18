#include <stdio.h>

int main(void) {
  int month, day, year;


  printf("Enter date (mm/dd/yyyy): ");

  scanf("%d /%d /%d", &month, &day, &year);


  switch (month) {
    case 1:
    printf("January");
    break;
    case 2:
    printf("February");
    break;
    case 3: 
    printf("March");
    break;
    case 4: 
    printf("April");
    break;
    case 5: 
    printf("May");
    break;
    case 6:
    printf("June");
    break;
    case 7: 
    printf("July");
    break;
    case 8: 
    printf("August");
    break;
    case 9:
    printf("September");
    break;
    case 10:
    printf("October");
    break;
    case 11:
    printf("November");
    break;
    case 12:
    printf("December");
    break;
    default: 
    printf("This is not a month");
     return 0;
  } 

  
 if (day < 1 || day > 31) {
    printf(" This is not a day in the month!");
    return 0;
 } else {
  printf(" %d", day);
  switch (day) {
    case 1: case 21: case 31:
    printf("st");
    break;
    case 2: case 22:
    printf("nd");
    break;
    case 3: case 23:
    printf("rd");
    break;
    default:
    printf("th");
    break;
  } 
 }

    printf(" %d", year);
  
  return 0;
}