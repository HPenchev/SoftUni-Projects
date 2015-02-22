<?php

class SingleRoom extends Room
{
	const BED_COUNT = 1;
	const ROOM_TYPE = RoomType::Standard;
	const HAS_RESTROOM = TRUE;
	const HAS_BALCONY = FALSE;
	const EXTRAS = array('TV', 'air-conditioner');
	
	function __construct($roomNumber, $price)
	{
		parent::__construct(self::ROOM_TYPE, self::HAS_RESTROOM, self::HAS_BALCONY, self::BED_COUNT, $roomNumber, self::EXTRAS, $price);
	}
}