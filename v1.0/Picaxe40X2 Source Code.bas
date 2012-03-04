
init: 
	hi2csetup i2cmaster, %00000011, i2cslow_8, i2cbyte

main: 
	serrxd b0
	hi2cout (b0)

	goto main