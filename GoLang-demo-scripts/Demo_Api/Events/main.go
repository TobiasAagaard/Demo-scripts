package main

import (
	"example.com/events/routes"
	"github.com/gin-gonic/gin"
)

func main() {
	server := gin.Default()
	routes.SetupRoutes(server)
	server.Run("8080")
}
