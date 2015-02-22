<?php

abstract class Room implements iReservable
{
	private $reservations;
	private $roomType;
	private $hasRestroom;
	private $hasBalcony;
	private $bedCount;
	private $roomNumber;
	private $extras;
	private $price;
	
	public function __construct($roomType, $hasRestroom, $hasBalcony, $bedCount, $roomNumber, $extras, $price)
	{	
		$this->setReservations();
		$this->setRoomType($roomType);
		$this->setHasRestroom($hasRestroom);
		$this->setHasBalcony($hasBalcony);
		$this->setBedCount($bedCount);
		$this->setRoomNumber($roomNumber);
		$this->setExtras($extras);
		$this->setPrice($price);
	}
	
	public function getReservations()
	{
		return $this->reservations;
	}
	
	public function setReservations()
	{		
		$this->reservations = array();
	}
	
	public function getRoomType()
	{
		return $this->roomType;
	}
	
	public function setRoomType($roomType)
	{
		if ($roomType != RoomType::Standard && $roomType != RoomType::Gold && $roomType != RoomType::Diamond) {
			throw new InvalidArgumentException("Room type can be Standard, Gold and Diamond only", 1);
		}	
							
		$this->roomType = $roomType;
	}
	
	
	public function getHasRestroom()
	{
		return $this->hasRestroom;
	}
	
	public function setHasRestroom($hasRestroom)
	{
		if (!is_bool($hasRestroom)) {
			throw new InvalidArgumentException('$hasRestroom can be true or false only', 1);
		}
		
		$this->hasRestroom = $hasRestroom;
	}
	
	public function getHasBalcony()
	{
		return $this->hasBalcony;
	}
	
	public function setHasBalcony($hasBalcony)
	{
		if (!is_bool($hasBalcony)) {
			throw new InvalidArgumentException('$hasBalcony can be true or false only', 1);
		}
		
		$this->hasBalcony = $hasBalcony;
	}
	
	public function getBedCount()
	{
		return $this->bedCount;
	}
	
	public function setBedCount($bedCount)
	{
		if (!(is_int($bedCount) && $bedCount > 0)) {
			throw new InvalidArgumentException('Bed count has to be an integer number more than 0', 1);
		}
		
		$this->bedCount = $bedCount;
	}
	
	public function getRoomNumber()
	{
		return $this->roomNumber;
	}
	
	public function setRoomNumber($roomNumber)
	{
		if (!(is_int($roomNumber) || (is_string($roomNumber)))) {
			throw new InvalidArgumentException("Room number can be a number or a string only");
		}
		
		$this -> roomNumber = $roomNumber;
	}
	
	public function getExtras()
	{
		return $this->extras;
	}
	
	public function setExtras($extras)
	{
		$this->extras = $extras;
	}
	
	public function getPrice()
	{
		return $this->price;
	}
	
	public function setPrice($price)
	{
		if (!(is_numeric($price) && $price >= 0)) {
			throw new InvalidArgumentException("Price has to be a number not less than 0", 1);				
		}
		
		$this->price = $price;
	}
	
	public function addReservation($reservation)
	{
		$this->checkWhetherIsReservation($reservation);
		$this->checkNewReservationForOverlapping($reservation);
		array_push($this->reservations, $reservation);	
	}
	
	public function removeReservation($reservation)
	{
		$this->checkWhetherIsReservation($reservation);
		if(($key = array_search($reservation, $this->reservations)) !== false) {
    		unset($messages[$key]);
		} else {
			throw new Exception("Reservation not found");
		}
	}
	
	public function toString()
	{
		$output = "Room: " . $this->getRoomNumber() . "<br/>";
		$output .= "Room type: " . $this->getRoomType() . "<br/>";
		$output .= "Restroom: ";
		if ($this->getHasRestroom()) {
			$output .= "Yes";
		} else {
			$output .= "No";
		}
		
		$output .= "<br/>Balcony: ";
		if ($this->getHasBalcony()) {
			$output .= "Yes";
		} else {
			$output .= "No";
		}
		
		$output .= "<br/>Bed count: " . $this->getBedCount() . "<br/>";
		$output .= "Extras: " . implode(", ", $this->getExtras()) . "<br/>";
		$output .= "Price: " . $this->getPrice() . "<br/>";
		$output .= "Reservations:<br/>";
		foreach ($this->getReservations() as $key => $reservation) {
			$output .= $reservation->toString() . "<br/>";
		}
		
		return $output;
	} 
	
	private function checkNewReservationForOverlapping($newReservation)
	{
		foreach ($this->reservations as $key => $existingReservation) {
			$this->compareTwoReservationsForOverlapping($newReservation, $existingReservation);
		}
	}
	
	private function compareTwoReservationsForOverlapping(Reservation $newReservation, Reservation $existingReservation)
	{
		if (
		($newReservation->getStartDate() >= $existingReservation->getStartDate() && 
		$newReservation->getStartDate() <= $existingReservation->getEndDate()) ||
		($newReservation->getEndDate() <= $existingReservation->getEndDate() &&
		$newReservation->getEndDate() >= $existingReservation->getStartDate()) ||
		($newReservation->getStartDate() <= $existingReservation->getStartDate() &&
		$newReservation->getEndDate() >= $existingReservation->getEndDate())
		) {
			throw new EReservationException();
		}
	}
	
	private function checkWhetherIsReservation($reservation)
	{
		if (!is_a($reservation, "Reservation")) {
				throw new InvalidArgumentException("Reservations array can contain reservations only", 1);
			}
	}
}