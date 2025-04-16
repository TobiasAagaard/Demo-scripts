package models

import "time"

type Event struct {
	ID        int
	Name      string
	CreatedAt time.Time
}
