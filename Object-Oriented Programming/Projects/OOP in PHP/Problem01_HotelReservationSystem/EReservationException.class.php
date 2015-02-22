<?php

class EReservationException extends  Exception
{
	public function __construct()
	{
		parent::__construct("Reservations time period overlapping", 101);
	}
}
