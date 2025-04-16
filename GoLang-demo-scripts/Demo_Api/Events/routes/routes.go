package routes

import (
	"github.com/gin-gonic/gin"
)

func SetupRoutes(server *gin.Engine) {
	server.GET("/events")
	server.POST("/events")
}
