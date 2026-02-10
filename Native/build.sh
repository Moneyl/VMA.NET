#!/bin/bash
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(dirname "$SCRIPT_DIR")"

g++ -O3 -shared -fPIC -fvisibility=hidden \
    -DVMA_IMPLEMENTATION \
    -DVMA_DYNAMIC_VULKAN_FUNCTIONS=1 \
    -DVMA_STATIC_VULKAN_FUNCTIONS=0 \
    '-DVMA_CALL_PRE=__attribute__((visibility("default")))' \
    -I "${ROOT_DIR}/Dependencies/VulkanMemoryAllocator/include/" \
    -Wl,--version-script="${SCRIPT_DIR}/vma.map" \
    -o "${SCRIPT_DIR}/libvma.so" \
    "${SCRIPT_DIR}/vma.cpp"
