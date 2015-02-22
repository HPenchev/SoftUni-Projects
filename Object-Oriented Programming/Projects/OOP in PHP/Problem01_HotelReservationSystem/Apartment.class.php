<?php

class Apartment extends Room
{
	const BED_COUNT = 4;
	const ROOM_TYPE = RoomType::Diamond;
	const HAS_RESTROOM = TRUE;
	const HAS_BALCONY = TRUE;
	const EXTRAS = array("TV", "air-conditioner", "refrigerator", "kitchen-box", "mini-bar", "bathtub", "free Wi-fi");
	
	function __construct($roomNumber, $price)
	{
		parent::__construct(self::ROOM_TYPE, self::HAS_RESTROOM, self::HAS_BALCONY, self::BED_COUNT, $roomNumber, self::EXTRAS, $price);
	}
}
