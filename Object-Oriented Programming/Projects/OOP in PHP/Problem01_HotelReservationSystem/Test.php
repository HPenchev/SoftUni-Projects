<?php

spl_autoload_register("load_hotel_classes");
date_default_timezone_set('Europe/Sofia');

$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = new DateTime("24.10.2014");
$endDate = new DateTime("26.10.2014");
$reservation = new Reservation($startDate, $endDate, $guest);
BookingManager::bookRoom($room, $reservation);

$startDate2 = new DateTime("25.10.2014");
$endDate2 = new DateTime("27.10.2014");
$reservation2 = new Reservation($startDate2, $endDate2, $guest);

BookingManager::bookRoom($room, $reservation2);

$room2 = new Bedroom(140, 199);
$room3 = new Apartment(1400, 399);

$rooms = array($room, $room2, $room3);

$filteredRooms = array_filter ($rooms, function ($v) { return $v->getHasBalcony() == TRUE; });

echo"<br\>";

foreach ($filteredRooms as $key => $room) {
	echo $room->toString();
}

$filteredRooms = array_filter ($rooms, function ($v) { return in_array("bathtub",$v->getExtras()); });

echo"<br\>";
echo"<br\>";
foreach ($filteredRooms as $key => $room) {
	echo $room->toString();
}

function load_hotel_classes($className)
{
	include_once "$className.class.php";	
}