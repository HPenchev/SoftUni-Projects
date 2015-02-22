<?php

class Guest
{
	private $firstName;	
	private $lastName;
	private $id;
	
	public function __construct($firstName, $lastName, $id)
	{
		$this->setFirstName($firstName);
		$this->setLastName($lastName);
		$this->setId($id);
	}
	
	public function getFirstName()
	{
		return $this->firstName;
	}
	
	public function setFirstName($firstName)
	{
		$pattern = "[^A-Za-z]";
		$this->checkArgument($firstName, $pattern);
		$this->firstName = $firstName;
	}	
	
	public function getLastName()
	{
		return $this->lastName;
	}
	
	public function setLastName($lastName)
	{
		$pattern = "[^A-Za-z]";
		$this->checkArgument($lastName, $pattern);
		$this->lastName = $lastName;
	}	
	
	public function getId()
	{
		return $this->id;
	}
	
	public function setID($id)
	{
		$pattern = "[^A-Za-z0-9]";
		$this->checkArgument($id, $pattern);
		$this->id = $id;
	}
	
	function checkArgument($subject, $pattern)
	{		
		$doesMatch = preg_match($pattern, $subject);
		if ($doesMatch || empty($subject)) {
			throw new InvalidArgumentException("Invalid argument", 1);		
		}		
	}
	
	public function toString()
	{
		$output = "Name: " . $this->getFirstName() . " " . $this->getLastName(); 
		$output .= "<br/>ID: " . $this->getId();
		return $output;
	}
}
