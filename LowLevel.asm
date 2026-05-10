[bits 32]
global _start
extern Main

section .text
_start:
    call Main
    cli
    hlt
