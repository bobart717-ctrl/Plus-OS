[bits 32]
global outb
global inb

section .text

; Записать байт в порт: outb(port, data)
outb:
    mov dx, [esp + 4]
    mov al, [esp + 8]
    out dx, al
    ret

; Прочитать байт из порта: inb(port)
inb:
    mov dx, [esp + 4]
    in al, dx
    ret
