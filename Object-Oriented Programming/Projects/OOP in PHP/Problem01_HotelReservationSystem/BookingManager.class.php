<?php

class BookingManager
{
	public static function bookRoom($room, $reservation) 
	{
		if(!(is_a($room, 'Room') && is_a($reservation, "Reservation"))) {
			throw new InvalidArgumentException("Reservation or room is invalid");
		}
		
		try {
		$room->addReservation($reservation);
		echo "<p>Reservation successful</p>";
		} catch (EReservationException $e){
			echo $e->getMessage() . " Booking not successful.";
		}
		
		
	}
}