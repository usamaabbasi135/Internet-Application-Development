#include<iostream>
#include<fstream>
#include <Windows.h>

using namespace std;
void createFile();
int main() {

    int seconds;
    cout << "Enter value of seconds. The program would generate new numbers after X seconds: " << endl;
    cin >> seconds;
    int milli_seconds = seconds * 1000;
    
    while (1)
    {
        createFile();
        Sleep(milli_seconds);
    }


    return 0;
    
}

void createFile() {


    ofstream file("RandomNumbers.html");           //creating an HTML file 
    file << "<html>" << endl;
    file << "<head>" << endl;
    file << "<title> Random Numbers </title>" << endl;
    file << "</head>" << endl;
    file << "<body>" << endl;
    file << "<h1>Random Numbers</h1>" << endl;
    file << "The random numbers are: </br> " << endl;    //Writting initial line to the file 
    srand(time(0));   //This function would help in generating new random number every time the program runs
    int randomNumber[5]; //Creating an array to store random numbers

    //This loop would generate and add the random numbers to the array and file as well
    for (int i = 0; i < 5; i++) {
        randomNumber[i] = rand();
        file << randomNumber[i] << endl << "</br>";
    }
    file << "</body>" << endl;
    file << "</html>" << endl;
    //Closing the file
    file.close();
}
