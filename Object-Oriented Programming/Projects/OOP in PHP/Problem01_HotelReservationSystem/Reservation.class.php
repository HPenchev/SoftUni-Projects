<?php

class Reservation
{
    private $startDate;
	private $endDate;
	private $guest;
	
	public function __construct(DateTime $startDate, DateTime $endDate, Guest $guest)
	{
		$this->setStartDate($startDate);
		$this->setEndDate($endDate);
		$this->setGuest($guest);
	}
	
	public function getStartDate()
	{
		return $this->startDate;
	}
	
	public function setStartDate($startDate)
	{		
		$this->startDate = $startDate;
	}
	
	public function getEndDate()
	{
		return $this->endDate;
	}
	
	public function setEndDate($endDate)
	{
		if($endDate < $this->getStartDate()) {
			
			throw new InvalidArgumentException("End date has to be after start date", 1);
		}
		$this->endDate = $endDate;
	}
	
	public function getGuest()
	{
		return $this->guest;
	}
	
	public function setGuest($guest)
	{
		$this->guest = $guest;
	}
	
	public function toString()
	{
		//$output = $this->getStartDate()->format('d-m-Y');
		$output = "Start date: " . $this->getStartDate()->format('d-m-Y'); 
		$output .= "<br/>End date: " . $this->getEndDate()->format('d-m-Y');
		$output .= "<br/>Guest information:<br/>" . $this->getGuest()->toString();
		return $output;
	}	
}