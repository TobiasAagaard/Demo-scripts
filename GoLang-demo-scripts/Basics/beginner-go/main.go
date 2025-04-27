package main

import (
	"fmt"
)

func main() {

	var (
		name       string = "Tobias"
		age        int    = 12
		girlfreind bool   = true
	)
	fmt.Printf("Hello my name is %s\n I am %d years old\n Do I have a girlfrind? %t\n", name, age, girlfreind)

	result := add(3, 5)

	fmt.Println("This is the result", result)

	if age >= 18 {
		fmt.Println("You're an adult")
	} else if age >= 13 {
		fmt.Println("You're an teenager")
	} else {
		fmt.Println("You're a child")
	}

	fruits := [5]string{
		"Apple", "Banana", "Orange",
	}

	fmt.Printf(fruits[2])

}

func add(a int, b int) int {
	return a + b
}
