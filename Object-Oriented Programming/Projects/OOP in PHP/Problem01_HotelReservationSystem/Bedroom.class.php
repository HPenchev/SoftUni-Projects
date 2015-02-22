<?php

class Bedroom extends Room
{
	const BED_COUNT = 2;
	const ROOM_TYPE = RoomType::Gold;
	const HAS_RESTROOM = TRUE;
	const HAS_BALCONY = TRUE;
	const EXTRAS = array("TV", "air-conditioner", "refrigerator", "mini-bar", "bathtub");
	
	function __construct($roomNumber, $price)
	{
		parent::__construct(self::ROOM_TYPE, self::HAS_RESTROOM, self::HAS_BALCONY, self::BED_COUNT, $roomNumber, self::EXTRAS, $price);
	}
}