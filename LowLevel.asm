[bits 32]

global cpu_reboot
cpu_reboot:
    jmp 0xFFFF0000 ; Прыжок на адрес перезагрузки BIOS
    ret
